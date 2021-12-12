import { Guid } from 'guid-typescript';

export interface AuthorReduced {
  id: Guid;
  firstname: string;
  lastname: string;
  aboutAuthor: string;
  picture: string;
}
