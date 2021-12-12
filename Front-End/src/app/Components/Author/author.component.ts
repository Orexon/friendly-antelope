import { Component, OnInit } from '@angular/core';
import { AuthorBook } from 'app/Models/Author/AuthorBook';
import SwiperCore, { Navigation, Controller } from 'swiper';

SwiperCore.use([Navigation, Controller]);

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent implements OnInit {
  //AuthorBooks: AuthorBook[] = [];
  constructor() {}
  AuthorBooks = [
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://www.shortlist.com/media/images/2019/05/40-coolest-sci-fi-book-covers-26-1556673634-CU5u-column-width-inline.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://www.shortlist.com/media/images/2019/05/40-coolest-sci-fi-book-covers-13-1556673626-FyFo-column-width-inline.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/91elh2ixGIL-678x1024.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/511bK58MFcL-683x1024.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/ASpellofWinter-626x1024.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/static1.squarespace-1.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/71j3RJ0ND2L-667x1024.jpg',
    },
    {
      id: 123456789,
      name: 'BestBook',
      category: 'SciFi',
      publicationDate: '19920718',
      coverPicture:
        'https://s26162.pcdn.co/wp-content/uploads/2019/11/91elh2ixGIL-678x1024.jpg',
    },
  ];
  breakpoints = {
    320: { slidesPerView: 1, spaceBetween: 0 },
    576: { slidesPerView: 2, spaceBetween: 0 },
    768: { slidesPerView: 2, spaceBetween: 10 },
    992: { slidesPerView: 3, spaceBetween: 10 },
    1200: { slidesPerView: 4, spaceBetween: 10 },
    1400: { slidesPerView: 4, spaceBetween: 10 },
    1800: { slidesPerView: 4, spaceBetween: 10 },
  };

  scrollbar: any = false;
  toggleScrollbar() {
    if (!this.scrollbar) {
      this.scrollbar = { draggable: true };
    } else {
      this.scrollbar = false;
    }
  }

  pagination: any = false;

  breakPointsToggle: boolean = false;

  breakpointChange() {
    this.breakPointsToggle = !this.breakPointsToggle;
    this.breakpoints = {
      320: { slidesPerView: 1, spaceBetween: 0 },
      576: { slidesPerView: 2, spaceBetween: 10 },
      768: { slidesPerView: 2, spaceBetween: 15 },
      992: { slidesPerView: 3, spaceBetween: 20 },
      1200: { slidesPerView: 4, spaceBetween: 10 },
      1400: { slidesPerView: 4, spaceBetween: 10 },
      1800: { slidesPerView: this.breakPointsToggle ? 7 : 4, spaceBetween: 10 },
    };
  }

  ngOnInit() {}
}
