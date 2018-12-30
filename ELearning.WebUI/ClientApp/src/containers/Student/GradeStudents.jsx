import React, { Component } from 'react';
import { Header, Dropdown } from 'semantic-ui-react';

import './GradeStudents.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import Grade from '../../components/Grades/Grade';


class GradeStudents extends Component {

    state = {

    }

    render() {

    const options = [{ key: 'angular', text: 'Angular', value: 'angular' },
        { key: 'css', text: 'CSS', value: 'css' },
        { key: 'design', text: 'Graphic Design', value: 'design' },
        { key: 'ember', text: 'Ember', value: 'ember' },
        { key: 'html', text: 'HTML', value: 'html' },
        { key: 'ia', text: 'Information Architecture', value: 'ia' },
        { key: 'javascript', text: 'Javascript', value: 'javascript' },
        { key: 'mech', text: 'Mechanical Engineering', value: 'mech' },
        { key: 'meteor', text: 'Meteor', value: 'meteor' },
        { key: 'node', text: 'NodeJS', value: 'node' },
        { key: 'plumbing', text: 'Plumbing', value: 'plumbing' },
        { key: 'python', text: 'Python', value: 'python' },
        { key: 'rails', text: 'Rails', value: 'rails' },
        { key: 'react', text: 'React', value: 'react' },
        { key: 'repair', text: 'Kitchen Repair', value: 'repair' },
        { key: 'ruby', text: 'Ruby', value: 'ruby' },
        { key: 'ui', text: 'UI Design', value: 'ui' }
        ]

        return (
            <div className='gradeContainer'>
                <div className='gradeStudents'>
                    <Header size='large'>Oceń innych</Header>
                    <div className='grades'>
                        <Dropdown placeholder='Student' search selection options={options} />
                        <Grade />
                    </div>

                </div>
                <div className='studentCode'>
                    <CodeWindow changeMode={true} code={'Hello'} />
                </div>
            </div>
        );
    }
}

export default GradeStudents;