<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/Iaaa/VehicleInspections/PermitInspectorsRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.IaaaVehicleInspectionsAdapter\XMLSchemas\Report2_permitInspectorsRequest.xsd" workingxmlfile="Report2_permitInspectorsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на Справка по лице за вписвания като председател на комисия/технически специалист в регистрирани пунктове за технически прегледи."/>									<newline/>								</children>							</paragraph>							<table>								<properties align="left" border="0"/>								<children>									<tablebody>										<children>											<tablerow>												<children>													<tablecell headercell="1">														<children>															<text fixtext="ЕГН на търсеният специалист в пункт за технически преглед">																<styles font-style="italic" font-weight="normal"/>															</text>														</children>													</tablecell>													<template match="n1:PermitInspectorsRequest" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<tablecell>																<children>																	<template match="n1:IdentNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</template>												</children>											</tablerow>										</children>									</tablebody>								</children>							</table>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>