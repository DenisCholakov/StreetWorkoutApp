import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  isLoggedIn = false;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
  }

  logout(): void {
    this.authService.logout();
    this.isLoggedIn = false;
  }
}
