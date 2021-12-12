import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthorReduced } from 'src/app/Models/Author/AuthorReduced';
import { environment } from 'src/environments/environment';
import { BookReduced } from 'src/app/Models/Book/BookReduced';
import { Guid } from 'guid-typescript';
import { NewComment } from 'src/app/Models/Comment/NewComment';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private http: HttpClient) {}

  getAllAuthors(
    pageSize: number,
    pageNumber: number
  ): Observable<AuthorReduced[]> {
    return this.http.get<AuthorReduced[]>(
      `${environment.apiUrl}/Author${pageSize}&${pageNumber}`
    );
  }
  getAllBooks(pageSize: number, pageNumber: number): Observable<BookReduced[]> {
    return this.http.get<BookReduced[]>(
      `${environment.apiUrl}/Book${pageSize}&${pageNumber}`
    );
  }

  getComments(
    id: Guid,
    pageNumber: number,
    pageSize: number
  ): Observable<Comment[]> {
    return this.http.get<Comment[]>(
      `${environment.apiUrl}/Comment/${id}&${pageSize}&${pageNumber}`
    );
  }

  createComment(data: any) {
    const headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.post<NewComment>(`${environment.apiUrl}/Comment`, data, {
      headers: headers,
    });
  }
}
