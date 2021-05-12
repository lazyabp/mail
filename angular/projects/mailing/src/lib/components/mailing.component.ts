import { Component, OnInit } from '@angular/core';
import { MailingService } from '../services/mailing.service';

@Component({
  selector: 'lib-mailing',
  template: ` <p>mailing works!</p> `,
  styles: [],
})
export class MailingComponent implements OnInit {
  constructor(private service: MailingService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
