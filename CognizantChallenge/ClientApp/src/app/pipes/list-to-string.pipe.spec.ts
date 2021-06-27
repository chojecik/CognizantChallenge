import { ListToStringPipe } from './list-to-string.pipe';

describe('ListToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new ListToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
