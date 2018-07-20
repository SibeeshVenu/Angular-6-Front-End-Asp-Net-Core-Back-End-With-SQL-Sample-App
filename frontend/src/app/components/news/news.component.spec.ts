import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from '../home/home.component';
import { MatCardModule, MatSelectModule, MatButtonModule } from '../../../../node_modules/@angular/material';
import { SingleNewsComponent } from '../single-news/single-news.component';
import { ApiService } from '../../services/api.service';
import { HttpModule } from '../../../../node_modules/@angular/http';
import { NewsRouterModule } from '../../modules/news-router/news-router.module';
import { NewsComponent } from '../news/news.component';
import { DummyComponent } from '../dummy/dummy.component';
import { APP_BASE_HREF } from '../../../../node_modules/@angular/common';
import { BrowserAnimationsModule } from '../../../../node_modules/@angular/platform-browser/animations';
import { Observable, observable } from '../../../../node_modules/rxjs';
import { News } from '../../models/news';

describe('NewsComponent', () => {
  let component: NewsComponent;
  let fixture: ComponentFixture<NewsComponent>;
  let apiService: ApiService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HomeComponent, SingleNewsComponent, NewsComponent, DummyComponent],
      imports: [MatCardModule, MatSelectModule, MatButtonModule, HttpModule, NewsRouterModule, BrowserAnimationsModule],
      providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        ApiService]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    apiService = TestBed.get(ApiService);
    spyOn(apiService, 'get').and.returnValue(new Observable<Array<News>>());
  });

  it('should get news', async(() => {
    component.getNews();
    fixture.detectChanges();
    expect(apiService.get).toHaveBeenCalled();
  }));
});
