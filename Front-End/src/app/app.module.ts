import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorsComponent } from './Components/Authors/authors.component';
import { BooksComponent } from './Components/Books/books.component';
import { HomeComponent } from './Components/Home/home.component';

@NgModule({
  declarations: [AppComponent, HomeComponent, BooksComponent, AuthorsComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
