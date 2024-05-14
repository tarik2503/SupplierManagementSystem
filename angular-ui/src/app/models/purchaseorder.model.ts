export interface PurchaseOrder {
    id: string;
    poNumber: string;
    deliveryDate:Date; 
    supplierId: string;
    products: any[];
  }