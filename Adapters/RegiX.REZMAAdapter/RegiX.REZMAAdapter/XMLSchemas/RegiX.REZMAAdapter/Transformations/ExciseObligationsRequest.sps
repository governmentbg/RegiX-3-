<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AM/REZMA/ExciseObligationsRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.REZMAAdapter\XMLSchemas\ExciseObligationsRequest.xsd" workingxmlfile="ExciseObligationsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h2">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на Справка за акцизни задължения"/>								</children>							</paragraph>							<template match="n1:ExciseObligationsRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<table>										<properties align="left" border="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell headercell="1">																<properties align="left" width="238"/>																<children>																	<text fixtext="Идентификатор(ЕИК):">																		<styles font-style="italic" font-weight="normal"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:Identifier" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>									<newline/>								</children>							</template>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>