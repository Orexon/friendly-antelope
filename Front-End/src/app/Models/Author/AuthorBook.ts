import { Guid } from 'guid-typescript';
import { Category } from '../Category';

export interface AuthorBook {
  id: Guid;
  name: string;
  authorId: Guid;
  category: Category;
  publicationDate: string;
  coverPicture: string;
}
