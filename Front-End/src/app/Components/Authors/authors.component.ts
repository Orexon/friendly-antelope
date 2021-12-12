import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
})
export class AuthorsComponent implements OnInit {
  //authors: AuthorReduced[] = [];
  loading: boolean = false;
  pageNumber: number = 1;
  pageSize: number = 8;

  authors = [
    {
      id: 123456789,
      firstname: 'Card Title 1',
      lastname: 'Lastname',
      aboutAuthor: 'Button ButtonButtonButtonButtonButtonButtonB',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/91elh2ixGIL-678x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 2',
      lastname: 'Lastname',
      aboutAuthor:
        'Button ButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/09/71wySuLKjcL-693x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 3',
      lastname: 'Lastname',
      aboutAuthor:
        'Button ButtonButtoon ButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/71j3RJ0ND2L-667x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 4',
      lastname: 'Lastname',
      aboutAuthor: 'uttonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/static1.squarespace-1.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 5',
      lastname: 'Lastname',
      aboutAuthor: 'Button ButtonButtonButtonButtonBnButtonButtonButtonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/ASpellofWinter-626x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 6',
      lastname: 'Lastname',
      aboutAuthor:
        'Button ButtonButtonButtonButttonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/511bK58MFcL-683x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 7',
      lastname: 'Lastname',
      aboutAuthor:
        'Button ButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButton',
      picture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/07/81oLO0iEdGL-678x1024.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 8',
      lastname: 'Lastname',
      aboutAuthor:
        'Button onButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButtonButton',
      picture:
        'https://www.shortlist.com/media/images/2019/05/40-coolest-sci-fi-book-covers-13-1556673626-FyFo-column-width-inline.jpg',
    },
    {
      id: 123456789,
      firstname: 'Card Title 9',
      lastname: 'Lastname',
      aboutAuthor:
        'Button ButtonButtonButtonButtonButtonButtonButtonBuButton n',
      picture:
        'https://www.shortlist.com/media/images/2019/05/40-coolest-sci-fi-book-covers-26-1556673634-CU5u-column-width-inline.jpg',
    },
  ];

  constructor() {}

  ngOnInit() {
    this.loading = true;
  }

  // getAuthorsList() {
  //   this.sharedService
  //     .getAllAuthors(this.pageSize, this.pageNumber)
  //     .subscribe((data) => {
  //       this.authors = data;
  //     });
  // }
}
