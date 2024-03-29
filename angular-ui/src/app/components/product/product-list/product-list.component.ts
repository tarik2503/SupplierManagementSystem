import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../services/product.service';
import { SupplierService } from '../../../services/supplier.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  suppliersMap: Map<string, string> = new Map();

  constructor(
    private productService: ProductService,
    private supplierService: SupplierService
  ) {}

  ngOnInit(): void {
    this.loadSuppliers();
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (product) => {
        this.products = product;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  loadSuppliers(): void {
    this.supplierService.getAllSuppliers().subscribe((suppliers) => {
      suppliers.forEach((supplier) => {
        this.suppliersMap.set(supplier.id, supplier.supplierName);
      });
    });
  }
  getSupplierName(supplierId: string): string {
    return this.suppliersMap.get(supplierId) || 'Supplier Not Found';
  }

  deleteFn(id: string) {
    this.productService.deleteProduct(id).subscribe({
      next: (response) => {
        alert(response.title + ' is deleted successfully!');
        this.loadProducts();
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  createImagePath(serverPath: string) {
    return this.supplierService.getImageFullPath(serverPath);
  }
}
