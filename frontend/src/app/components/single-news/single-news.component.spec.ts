import { async, ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';

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

describe('SingleNewsComponent', () => {
  let component: SingleNewsComponent;
  let fixture: ComponentFixture<SingleNewsComponent>;
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
    apiService = TestBed.get(ApiService);
    spyOn(apiService, 'delete').and.returnValue(new Observable<any>());
    spyOn(apiService, 'post').and.returnValue(new Observable<any>());
    fixture = TestBed.createComponent(SingleNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should call api post', fakeAsync(() => {
    component.addOrRemoveFavorite();
    fixture.detectChanges();
    expect(apiService.post).toHaveBeenCalled();
  }));

  it('should call api delete', async(() => {
    const news = new News();
    news.newsId = 1;
    component.news = news;
    component.addOrRemoveFavorite();
    fixture.detectChanges();
    expect(apiService.delete).toHaveBeenCalled();
  }));
});
