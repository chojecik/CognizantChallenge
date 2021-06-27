import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'listToString'
})
export class ListToStringPipe implements PipeTransform {

  transform(value: Array<any>, ...args: any[]): any {
    return value.join(', ');
  }

}
