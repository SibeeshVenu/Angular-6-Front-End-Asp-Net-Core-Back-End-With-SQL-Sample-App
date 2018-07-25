import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NewsRouterModule } from './modules/news-router/news-router.module';
import { NavComponent } from './components/nav/nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { NewsMaterialModule } from './modules/news-material/news-material.module';
import { NewsComponent } from './components/news/news.component';
import { ApiService } from './services/api.service';
import { HttpModule } from '../../node_modules/@angular/http';
import { FormsModule } from '../../node_modules/@angular/forms';
import { SingleNewsComponent } from './components/single-news/single-news.component';
import { DummyComponent } from './components/dummy/dummy.component';
import { FourNotFourComponent } from './components/four-not-four/four-not-four.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    FooterComponent,
    NewsComponent,
    SingleNewsComponent,
    DummyComponent,
    FourNotFourComponent
  ],
  imports: [
    HttpModule, FormsModule, BrowserModule,
    NewsRouterModule, NewsMaterialModule, BrowserAnimationsModule
  ],
  providers: [ ApiService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
