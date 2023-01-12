import { describe, expect, it } from '@jest/globals';
import React from 'react';
import { render } from '@testing-library/react';
import Footer from '../src/components/Footer';

describe('Footer', () => {
    it('renders without crashing', () => {
        const renderedPage = render(<Footer/>);
        expect(renderedPage).toBeTruthy();
    });
}
);
