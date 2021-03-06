import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorComponent } from './Components/Author/author.component';
import { AuthorsComponent } from './Components/Authors/authors.component';
import { BookComponent } from './Components/Book/book.component';
import { BooksComponent } from './Components/Books/books.component';

import { HomeComponent } from './Components/Home/home.component';
import { NotFoundComponent } from './Components/NotFound/not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Authors', component: AuthorsComponent },
  { path: 'Books', component: BooksComponent },
  { path: 'Books/:id', component: BookComponent },
  { path: 'Author/:id', component: AuthorComponent },
  { path: '404', component: NotFoundComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '/404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
