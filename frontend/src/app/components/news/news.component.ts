import { Component, OnInit } from '@angular/core';
import { Route, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { ApiService } from '../../services/api.service';
import { Constants } from '../../constants';
import { News } from '../../models/news';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  searchType: string;
  searchText: string;
  news: Array<News> = new Array<News>();

  constructor(private apiService: ApiService,
    private activatedRoute: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.getNews();
  }

  getNews() {
    this.activatedRoute.data.subscribe((data) => this.searchType = data.searchType);
    if (this.searchType === 'news/getAll?searchType=' + Constants.UrlConstants.search) {
      this.activatedRoute.params.subscribe((params) => {
        this.searchText = params['searchText'];
      });
      this.searchType = this.searchType + this.searchText;
    }
    this.apiService.get(this.searchType)
      .subscribe(
        data => {
          if (data.length > 0) {
            this.bindNews(data.slice(0, 10));
          } else {
            alert('Nothing found!');
          }
        },
        error => {
          alert('Invalid news collection found');
        });
  }

  bindNews(data: Array<News>) {
    data.forEach((n: News) => {
      // if (n.urlToImage) {
      // n.title = n.title.substring(0, 30);
      this.news.push(n);
      // }
    });
  }

  validateNews(news: News) {
    return news.author;
  }

}
