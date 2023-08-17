import { IEmployee } from './employee';

export interface ICompany {
  id: string;
  name: string;
  city: string;
  phone: string;
  employees: IEmployee[];
}
