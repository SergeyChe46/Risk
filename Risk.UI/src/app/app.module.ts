import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyListComponent } from './company/company-list/company-list.component';
import { HttpClientModule } from '@angular/common/http';
import { CompanyDetailComponent } from './company/company-detail/company-detail.component';
import { CreateCompanyComponent } from './company/create-company/create-company.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CompanyListComponent,
    CompanyDetailComponent,
    CreateCompanyComponent,
    EmployeeListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
