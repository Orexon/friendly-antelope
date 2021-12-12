import { Guid } from 'guid-typescript';

export interface NewComment {
  entityId: Guid;
  commentContent: string;
}
