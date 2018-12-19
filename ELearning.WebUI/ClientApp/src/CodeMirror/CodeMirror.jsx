import React, { Component } from 'react';
import CodeMirror from 'react-codemirror';

import './CodeMirror.scss';
import 'codemirror/lib/codemirror.css';
import 'codemirror/mode/clike/clike';
import 'codemirror/theme/neat.css';
import 'codemirror/addon/edit/closebrackets.js';
import 'JSCPP/lib/index.js';


class Codemirror extends Component {
    constructor() {
        super();
        this.state = {
            name: 'CodeMirror',
            code: '// Code Here'
        };
    }


    updateCode(newCode) {
        this.setState({
            code: newCode,
        });
    }

    render() {

        let options = {
            lineNumbers: true,
            mode: 'text/x-c++src',
            theme: 'neat',
            autoCloseBrackets: true,
        };

        return (
            <div>
                <CodeMirror value={this.state.code} onChange={this.updateCode.bind(this)} options={options} />
            </div>
        );
    }
}

export default Codemirror;
