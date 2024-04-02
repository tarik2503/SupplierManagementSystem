import { resolve } from "path/posix";
import { LastPONumberService } from "../services/last-ponumber.service";

export default class PONumberGenerator{
  constructor(private lastPONumberService:LastPONumberService){}

      generateNextPONumber(): string {
        const currentYearMonth = this.getCurrentYearMonth();
        const lastPONumber = this.getLastPONumber(); 
        const nextNumber = lastPONumber + 1;
        this.lastPONumberService.updateLastPONumber(nextNumber)
        return `${currentYearMonth}-${this.formatNumber(nextNumber)}`;
      }

        private getCurrentYearMonth(): string {
        const now = new Date();
        const year = now.getFullYear();
        const month = now.getMonth() + 1; 
        return `${year}${month.toString().padStart(2, '0')}`;
      }

       getLastPONumber(): number{
        this.lastPONumberService.getLastPONumber().subscribe({
          next: (response) => {
           const lastNumber = response
           return lastNumber
          } 
        }); 
        return 1000
      }
      private formatNumber(number: number): string {
        return number.toString().padStart(4, '0');
      }
}