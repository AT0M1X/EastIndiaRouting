module.exports = {
    preset: 'ts-jest',
    testEnvironment: 'jsdom',
    transform: {
        "^.+\\.svg$": "<rootDir>/__tests__/__mocks__/svgTransform.js",
        "^.+\\.(js|jsx)$": "babel-jest",
        '^.+\\.ts?$': 'ts-jest'
    },

    transformIgnorePatterns: [
        "node_modules/(?!(react-router-dom|react-datepicker|DatePicker)/)",
    ],

    moduleNameMapper: {'\\.(css|scss)$': '<rootDir>/__tests__/__mocks__/styleMock.js'},

    testRegex: "(/__tests__/.*|(\\.|/)(test|spec))\\.tsx?$",

    setupFilesAfterEnv: [ "@testing-library/jest-dom/extend-expect" ]
};
