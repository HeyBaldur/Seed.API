import { Directive, ElementRef, Input, OnInit } from '@angular/core';

// Change the appearance or behavior of DOM elements and Angular components with attribute directives.
@Directive({
    selector: '[appHighlight]'
})
export class HighlightDirective implements OnInit {

    /* A property decorator that allows the value of the `appHighlight` input to be passed to the
    directive. */
    @Input() textFontWeight: string = '';

    constructor(private _el: ElementRef) { }
    ngOnInit(): void {
        /* Setting the background color of the element to the value of the `appHighlight` input. */
        this._el.nativeElement.style.fontWeight = this.textFontWeight;
    }
}