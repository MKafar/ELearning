import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css';
import 'semantic-ui-react';

import './App.css';
import Menu from './components/Menu/Menu.jsx';
import CodeMirror from './components/CodeMirror/CodeMirror.jsx';
import Output from './components/CodeMirror/Output.jsx';

class App extends Component {


  state = {
    exercises: [
      { number: 1, title: 'Jakiś tytuł ćwiczenia' },
      { number: 2, title: 'B' },
      { number: 3, title: 'C' },
      { number: 4, title: 'D' },
      { number: 5, title: 'E' },
      { number: 6, date: '01.01.18', title: 'Kolejny długaśny bardzo długi tytuł, no bardzo długi ffffffffffffffffff ffffffffffffffffffffffff' }
    ],
    searches: [
      { date: '01.02.18', lab: 'PP', exercise: 'A', student: 'Mateusz M'},
      { date: '02.02.18', lab: 'PP', exercise: 'B', student: 'Mateusz A'},
      { date: '03.02.18', lab: 'PP', exercise: 'A', student: 'Mateusz K'}
    ]
  }



  render() {

    return (
      <div className='App'>
        <div className=" block">
          <div className="menu">
            <Menu></Menu>
          </div>
          <div>
            <CodeMirror></CodeMirror>
          </div>
          
          <Output></Output>
        </div>









        {/* 
        // tabela szukania
           { this.state.searches.map((search) => {
           return <SearchTable
           date = { search.date }
           lab = { search.lab }
           exercise = { search.exercise }
           student = { search.student } />
           })}
        
        
        //lista zadań
        <div className = 'detailList'>
            {this.state.exercises.map((exercise) => {
              return <DetailList
                number = { exercise.number }
                title = { exercise.title }
                date = { exercise.date }/>
            } )}
          </div> */}


        {/*
      <div className = "menu">
      <Menu></Menu>
      </div>
        <div className="logincontainer">
          <LoginInput></LoginInput>
          <LoginButton></LoginButton>
        </div>
        

         <div className='coding'>
          <Codemirror></Codemirror>
          <Output></Output>
        </div>
        */}

      </div>
    );
  }
}

export default App;