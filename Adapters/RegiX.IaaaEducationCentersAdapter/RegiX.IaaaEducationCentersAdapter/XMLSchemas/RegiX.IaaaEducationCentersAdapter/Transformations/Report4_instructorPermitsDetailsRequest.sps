<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsInstructorsReportRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.IaaaEducationCentersAdapter\XMLSchemas\Report4_instructorPermitsDetailsRequest.xsd" workingxmlfile="Report4_instructorPermitsDetailsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им "/>								</children>							</paragraph>							<newline/>							<table>								<properties align="left" border="0"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell headercell="1">														<children>															<text fixtext="ЕГН на търсеният преподавател:"/>														</children>													</tablecell>													<template match="n1:PermitsInstructorsRequest" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<tablecell>																<children>																	<template match="n1:SubjectIdentNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</template>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>						</children>					</template>					<newline/>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>