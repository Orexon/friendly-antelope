import { Guid } from 'guid-typescript';
import { Category } from '../Category';
import { PublicationDate } from '../PublicationDate';

export interface NewBook {
  name: string;
  authorId: Guid;
  category: Category;
  language: string;
  about: string;
  publicationDate: PublicationDate;
  coverPicture: string;
}
