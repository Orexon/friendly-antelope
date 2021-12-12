import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorsComponent } from './Components/Authors/authors.component';
import { BooksComponent } from './Components/Books/books.component';
import { HomeComponent } from './Components/Home/home.component';
import { NotFoundComponent } from './Components/NotFound/not-found.component';
import { AuthorComponent } from './Components/Author/author.component';
import { BookComponent } from './Components/Book/book.component';
import { SwiperModule } from 'swiper/angular';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BooksComponent,
    BookComponent,
    AuthorsComponent,
    AuthorComponent,
    NotFoundComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, SwiperModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
