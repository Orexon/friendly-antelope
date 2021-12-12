import { Guid } from 'guid-typescript';

export class Entity {
  id: Guid;

  constructor(id: Guid) {
    this.id = id;
  }
}
