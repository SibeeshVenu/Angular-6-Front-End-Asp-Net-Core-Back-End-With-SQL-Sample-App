import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router } from '../../../../node_modules/@angular/router';
import { News } from '../../models/news';
import { Constants } from '../../constants';

@Component({
  selector: 'app-single-news',
  templateUrl: './single-news.component.html',
  styleUrls: ['./single-news.component.css']
})
export class SingleNewsComponent implements OnInit {

  @Input()
  news: News = new News;

  constructor(private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
  }
  addOrRemoveFavorite() {
    if (this.news.newsId) {
      this.apiService.delete(Constants.UrlConstants.removeFromFavorites, this.news)
        .subscribe(
          data => {
            window.location.reload();
          },
          error => {
            console.log(error);
          });
    } else {
      this.apiService.post(Constants.UrlConstants.addToFavorites, this.news)
        .subscribe(
          data => {
            alert('News addded to favorites!');
          },
          error => {
            alert(error.error);
          });
    }
  }
}
