import React from "react";
import App from "./App";
import '@ftop/styles/dist/index.css';
import { createRoot } from 'react-dom/client';

const container = document.getElementById('root');
const root = createRoot(container!);
root.render(<App />);
