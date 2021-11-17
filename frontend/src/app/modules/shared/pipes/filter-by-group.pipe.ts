import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterByGroup'
})
export class FilterByGroupPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
