import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyDetailComponent } from './company/company-detail/company-detail.component';
import { CompanyListComponent } from './company/company-list/company-list.component';
import { CreateCompanyComponent } from './company/create-company/create-company.component';

const routes: Routes = [
  { path: 'add-company', component: CreateCompanyComponent },
  { path: 'company/:id', component: CompanyDetailComponent },
  { path: '', component: CompanyListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
