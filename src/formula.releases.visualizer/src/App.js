import 'heartthrob';
import './App.css'
import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Release from './Release';

function App() {
  return (
    <div className="container">
      <Router>
        <Switch>
          <Route path="/release/:filename" component={Release} />
          <Route>
            <div>Something went wrong...</div>
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
