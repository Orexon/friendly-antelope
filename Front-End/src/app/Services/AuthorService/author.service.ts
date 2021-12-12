import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { AuthorReduced } from 'src/app/Models/Author/AuthorReduced';
import { environment } from 'src/environments/environment';
import { Guid } from 'guid-typescript';
import { Author } from 'src/app/Models/Author/Author';
import { NewAuthor } from 'src/app/Models/Author/NewAuthor';
@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  constructor(private http: HttpClient) {}

  getAuthors(
    pageSize: number,
    pageNumber: number
  ): Observable<AuthorReduced[]> {
    return this.http.get<AuthorReduced[]>(
      `${environment.apiUrl}/Author/${pageSize}&${pageNumber}`
    );
  }

  getAuthor(id: Guid): Observable<Author> {
    return this.http.get<Author>(`${environment.apiUrl}/Author/${id}`);
  }

  createAuthor(data: any) {
    const headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.post<NewAuthor>(`${environment.apiUrl}/Author`, data, {
      headers: headers,
    });
  }

  editAuthor(id: Guid, data: any): Observable<Author> {
    const headers = new HttpHeaders();
    headers.append('Accept', 'application/json');

    return this.http.patch<Author>(`${environment.apiUrl}/Author/${id}`, data, {
      headers: headers,
    });
  }

  deleteAuthor(id: Guid) {
    return this.http.delete(`${environment.apiUrl}/Author/${id}`);
  }
}
