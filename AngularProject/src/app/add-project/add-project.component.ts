import { Component, OnInit } from '@angular/core';
import { Options } from 'ng5-slider';
import { Project} from '../project';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.scss']
})
export class AddProjectComponent implements OnInit {

  public addProject: Project = new Project();
  public start: string = new Date().toISOString().split('T')[0];
  public end: string = new Date().toISOString().split('T')[0];
  defaultSliderValue: number = 5;
  options: Options = {
    floor: 0,
    ceil: 30
  };
  constructor() { }

  ngOnInit() {
  }

}
