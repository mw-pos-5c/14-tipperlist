import { Pipe, PipeTransform } from '@angular/core';
import {TipperDto} from "../../../../models/tipperdto";

@Pipe({
  pure: false,
  name: 'filterByGroup'
})
export class FilterByGroupPipe implements PipeTransform {

  transform(value: TipperDto[], ...args: string[]): TipperDto[] {
    if (args[0] === undefined || args[0] === '') return value;
    return value.filter(x => x.groups.includes(args[0]));
  }

}
