import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { Book } from 'src/app/Models/Book/Book';
import { BookReduced } from 'src/app/Models/Book/BookReduced';
import { NewBook } from 'src/app/Models/Book/NewBook';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  constructor(private http: HttpClient) {}

  getBooks(): Observable<BookReduced[]> {
    return this.http.get<BookReduced[]>(`${environment.apiUrl}/Books`);
  }

  getBook(id: Guid): Observable<Book> {
    return this.http.get<Book>(`${environment.apiUrl}/Book/${id}`);
  }

  createBook(data: any) {
    const headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.post<NewBook>(`${environment.apiUrl}/Book`, data, {
      headers: headers,
    });
  }

  editBook(id: Guid, data: any): Observable<Book> {
    const headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.patch<Book>(`${environment.apiUrl}/Book/${id}`, data, {
      headers: headers,
    });
  }

  deleteBook(id: Guid) {
    return this.http.delete(`${environment.apiUrl}/Book/${id}`);
  }
}
