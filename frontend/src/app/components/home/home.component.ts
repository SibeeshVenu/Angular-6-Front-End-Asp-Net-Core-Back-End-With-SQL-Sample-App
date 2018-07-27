import { Component, OnInit, NgZone } from '@angular/core';
import { News } from '../../models/news';
import { Constants } from '../../constants';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  searchType: string;
  searchText: string;
  news: Array<News> = new Array<News>();
  selected = 'general';
  categoryNews: Array<News> = new Array<News>();

  constructor(private apiService: ApiService,
    private activatedRoute: ActivatedRoute,
    public zone: NgZone
  ) { }

  ngOnInit() {
    this.getTopHeadlines();
    this.getNewsCategoryWise();
  }

  loadNewsCategoryWise() {
    this.getNewsCategoryWise();
  }

  // Get the category wise news, news will be loaded according to the news drop down selection
  getNewsCategoryWise() {
    this.searchType = 'news/getAll?category=' + this.selected + '&searchType=' + Constants.UrlConstants.getTopHeadlinesNews;
    this.apiService.get(this.searchType)
      .subscribe(
        data => {
          if (data.length > 0) {
            this.bindNewsCategoryWise(data.slice(0, 10));
          } else {
            alert('Nothing found!');
          }
        },
        error => {
          alert('Invalid news collection found');
        });
  }

  // Bind the news to UI
  bindNewsCategoryWise(data: Array<News>) {
    this.zone.run(() => {
      this.categoryNews = [];
      data.forEach((n: News) => {
        if (n.urlToImage && this.validateNews(n)) {
          n.shortTitle = n.title.substring(0, 30);
          this.categoryNews.push(n);
        }
      });
    });
  }

  // Get top headlines news
  getTopHeadlines() {
    this.searchType = 'news/getAll?searchType=' + Constants.UrlConstants.getTopHeadlinesNews;
    this.apiService.get(this.searchType)
      .subscribe(
        data => {
          if (data.length > 0) {
            this.bindHeadlines(data.slice(0, 10));
          } else {
            alert('Nothing found!');
          }
        },
        error => {
          alert('Invalid news collection found');
        });
  }

  // Bind headlines to UI
  bindHeadlines(data: Array<News>) {
    data.forEach((n: News) => {
      if (n.urlToImage && this.validateNews(n)) {
        n.shortTitle = n.title.substring(0, 30);
        this.news.push(n);
      }
    });
  }

  validateNews(news: News) {
    return news.author;
  }
}
