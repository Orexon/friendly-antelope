import { Guid } from 'guid-typescript';
import { AuthorBook } from './AuthorBook';

export interface Author {
  id: Guid;
  firstname: string;
  lastname: string;
  aboutAuthor: string;
  picture: string;
  books: AuthorBook[];
}
