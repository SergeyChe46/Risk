import { Component, OnInit } from '@angular/core';
import { ICompany } from '../../shared/company';
import { CompanyService } from '../../company.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css'],
})
export class CompanyListComponent implements OnInit {
  constructor(private companyService: CompanyService) {}

  companies: ICompany[] = [];

  ngOnInit(): void {
    this.companyService.getAll().subscribe((data) => {
      this.companies = data;
    });
  }
}
