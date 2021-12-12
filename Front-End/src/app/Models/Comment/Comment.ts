import { Entity } from '../Entity';

export interface Comment {
  entityId: Entity;
  postDate: Date;
  commentContent: string;
}
