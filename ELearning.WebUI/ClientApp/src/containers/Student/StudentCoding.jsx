import React, { Component } from 'react';
import { Header, Button } from 'semantic-ui-react';

import './StudentCoding.scss';
import CodeMirror from '../../components/CodeMirror/CodeMirror';
import Output from '../../components/CodeMirror/Output';


class StudentCoding extends Component {

    state = {
        exercises: [
            { number: 1, title: 'Jakiś tytuł ćwiczenia' },
        ],

    }

    render() {

        const sendCodeHandler = () => {
            console.log('Treść');
        }

        return (
            <div className='codingStudent'>
                <Header size='large'>Jakiś student</Header>
                <div className='codingContainer'>
                    <div>
                        <CodeMirror></CodeMirror>
                    </div>
                    <div>
                        <Output></Output>
                        <Button onClick={sendCodeHandler}>Wyślij</Button>
                    </div>
                </div>
            </div>
        );
    }
}

export default StudentCoding;