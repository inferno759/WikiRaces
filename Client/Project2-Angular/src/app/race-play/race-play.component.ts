import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-race-play',
  templateUrl: './race-play.component.html',
  styleUrls: ['./race-play.component.css']
})
export class RacePlayComponent implements OnInit {

  currentURL: SafeUrl;
  randomURL = "https://en.wikipedia.org/wiki/Russia";


  setRaceUrl(): void {
    const inputURL = document.getElementById('selectWiki').nodeValue;
    this.currentURL = inputURL;
  }



  constructor(
    private domSanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
  }

}
