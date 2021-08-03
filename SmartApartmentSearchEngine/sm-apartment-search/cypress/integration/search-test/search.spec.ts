/// <reference types="cypress" />

describe('Search Automation', () => {
    it('Type in appartment and select state', () => {
      cy.visit('http://localhost:4200/search');

      cy.request('https://localhost:44366/health/live').then((response) => {
        expect(response.status).to.eq(200)
        expect(response).to.have.property('headers')
        expect(response).to.have.property('duration')
       });

      cy.get('#searchInput').type('Idlewylde');

      cy.get('.well')
      .should('have.length', 1)
      .last();

      cy.get('.title h3')
      .should('have.text', 'Astor Place')

      cy.get('.title p')
      .should('have.text', 'Atlanta')
  
    });
  });