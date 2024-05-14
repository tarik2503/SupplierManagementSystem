import { LastPONumberService } from "../services/last-ponumber.service";

export default class PONumberGenerator{
  constructor(private lastPONumberService:LastPONumberService){}

     async generateNextPONumber(): Promise<string>{
        const currentYearMonth = this.getCurrentYearMonth();
        const lastPONumber = await this.getLastPONumberAsync(); 
        const nextNumber = lastPONumber + 1;
        this.lastPONumberService.updateLastPONumber(nextNumber);
        return `${currentYearMonth}-${this.formatNumber(nextNumber)}`;
      }

        private getCurrentYearMonth(): string {
        const now = new Date();
        const year = now.getFullYear();
        const month = now.getMonth() + 1; 
        return `${year}${month.toString().padStart(2, '0')}`;
      }

      getLastPONumberAsync(): Promise<number> {
        return new Promise((resolve, reject) => {
          this.lastPONumberService.getLastPONumber().subscribe({
            next: (response) => resolve(response.lastNumber),
            error: reject
          });
        });
      }
      private formatNumber(number: number): string {
        return number.toString().padStart(4, '0');
      }
}