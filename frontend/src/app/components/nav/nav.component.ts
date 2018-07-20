import { Component, OnInit } from '@angular/core';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  searchText: string;
  constructor(private route: Router) { }

  ngOnInit() {
  }
  search() {
    this.redirect('search/' + this.searchText);
  }
  redirect(uri: string) {
    this.route.navigateByUrl('/DummyComponent', { skipLocationChange: true }).then(() => {
      this.route.navigate([uri]);
    });
  }
}
