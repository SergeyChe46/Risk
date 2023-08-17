import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICompany } from '../../shared/company';
import { CompanyService } from '../../company.service';

@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css'],
})
export class CompanyDetailComponent implements OnInit {
  companyId = '';
  company: ICompany = {
    city: '',
    employees: [],
    id: '',
    name: '',
    phone: '',
  };
  constructor(
    private route: ActivatedRoute,
    private companyService: CompanyService
  ) {
    this.companyId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.companyService
      .getById(this.companyId)
      .subscribe((data) => (this.company = data));
    setTimeout(() => console.log(this.company), 1000);
  }
}
