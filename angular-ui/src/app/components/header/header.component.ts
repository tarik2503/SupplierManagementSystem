import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements OnInit {
  constructor(private auth: AuthService) {}

  logOut() {
    this.auth.logOut();
  }
  ngOnInit(): void {}
}
