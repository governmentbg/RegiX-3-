<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="cr" uri="http://egov.bg/RegiX/CROZ/CROZ"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/CROZ/CROZ/ParticipantsResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.CROZAdapter\XMLSchemas\ParticipantsResponse.xsd" workingxmlfile="ParticipantsResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Централен регистър на особените залози"/>								</children>							</paragraph>							<paragraph paragraphtag="h2">								<properties align="center"/>								<children>									<text fixtext="Справка за търсене на участници по зададен идентификационен код и наименование"/>								</children>							</paragraph>							<template match="n1:ParticipantsResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<condition>										<children>											<conditionbranch xpath="count( n1:participantsList ) = 0">												<children>													<text fixtext="Няма намерени данни в регистъра!"/>												</children>											</conditionbranch>											<conditionbranch>												<children>													<template match="n1:participantsList" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<template match="cr:participant" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Участник "/>																	<autocalc xpath="position()"/>																	<text fixtext=" от "/>																	<autocalc xpath="count(../cr:participant)"/>																	<newline/>																	<newline/>																	<table>																		<properties border="1" width="100%"/>																		<children>																			<tablebody>																				<children>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left" width="493"/>																								<children>																									<text fixtext="Служебен идентификатор : "/>																									<template match="cr:particip_id" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="int"/>																											</content>																										</children>																									</template>																									<newline/>																									<text fixtext="Идентификационен код: "/>																									<template match="cr:particip_id_code" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="string"/>																											</content>																										</children>																									</template>																									<newline/>																									<text fixtext="Име на участник: "/>																									<template match="cr:name" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																											</content>																										</children>																									</template>																									<newline/>																									<text fixtext="Пълно име на участник: "/>																									<template match="cr:full_name" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="string"/>																											</content>																										</children>																									</template>																									<newline/>																								</children>																							</tablecell>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Град: "/>																									<template match="cr:city" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="string"/>																											</content>																										</children>																									</template>																									<newline/>																									<text fixtext="Адрес: "/>																									<template match="cr:address" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="string"/>																											</content>																										</children>																									</template>																									<newline/>																									<text fixtext="Пощенски код: "/>																									<template match="cr:zip" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<styles font-weight="normal"/>																												<format datatype="string"/>																											</content>																										</children>																									</template>																									<newline/>																								</children>																							</tablecell>																						</children>																					</tablerow>																				</children>																			</tablebody>																		</children>																	</table>																</children>															</template>														</children>													</template>												</children>											</conditionbranch>										</children>									</condition>									<newline/>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>