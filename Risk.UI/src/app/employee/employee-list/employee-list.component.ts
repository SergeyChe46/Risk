import { Component, Input } from '@angular/core';
import { IEmployee } from 'src/app/shared/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent {
  @Input() employees!: IEmployee[] | null;
}
