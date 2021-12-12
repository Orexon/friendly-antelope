import { Guid } from 'guid-typescript';

export interface BookReduced {
  id: Guid;
  name: string;
  authorId: Guid;
  coverPicture: string;
}
