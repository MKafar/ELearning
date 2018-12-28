import React from 'react'
import { Table } from 'semantic-ui-react'

//FIXME: naprawić wielokrotne tytuły tabel
const SearchTable = (props) => (
    
  <Table singleLine>
    <Table.Body>
      <Table.Row>
        <Table.Cell>{ props.date }</Table.Cell>
        <Table.Cell>{ props.lab }</Table.Cell>
        <Table.Cell>{ props.exercise }</Table.Cell>
        <Table.Cell>{ props.student }</Table.Cell>
      </Table.Row>
    </Table.Body>
  </Table>
)

export default SearchTable;
