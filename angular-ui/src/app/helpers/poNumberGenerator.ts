export default class PONumberGenerator{
      generateNextPONumber(): string {
        const currentYearMonth = this.getCurrentYearMonth();
        const lastPONumber = this.getLastPONumber(); // Retrieve the last PO number
        const nextNumber = lastPONumber + 1;
    
        // Store the next number back to your storage (not implemented)
        // this.storeLastPONumber(nextNumber);
    
        return `${currentYearMonth}-${this.formatNumber(nextNumber)}`;
      }

        private getCurrentYearMonth(): string {
        const now = new Date();
        const year = now.getFullYear();
        const month = now.getMonth() + 1; 
        return `${year}/${month.toString().padStart(2, '0')}`;
      }

      private getLastPONumber(): number {
       
        return 123; 
      }

      private formatNumber(number: number): string {
        return number.toString().padStart(4, '0');
      }
}